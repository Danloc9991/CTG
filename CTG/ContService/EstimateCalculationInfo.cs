namespace CTG.ContService
{
    public class EstimateCalculationInfo()
    {
        public double BaseCost { get; set; }
        public List<double> TabSpecificScalars { get; set; } 
        private List<Factor> Factors { get; set; }
       
        
        public List<double> EstimateWideScalars { get; set; } 
        public List<double> TabLineItems { get; set; }
        public List<double> EstimateWideLineItems { get; set; } 
      
      
        public double GetTotalCostConstruction() {
            double totalCost = BaseCost;
            Factors = new List<Factor>();
            for( int j=0; j < TabLineItems.Count; j++)
            {
                totalCost += TabLineItems[j];
            }
            for (int i = 0; i< TabSpecificScalars.Count;i++)
            {
                double percent = TabSpecificScalars[i];
                if(percent <0 || percent > 1)
                {
                    percent = 0;
                }
                 double addedCost = CalculateNewTotal(ContType.Percent,totalCost,percent);
                totalCost += addedCost;
                Factor factor = new Factor("fam", "Tab", "name", percent, addedCost);
                Factors.Add(factor); 
                
            }

            for( int k=0;k<EstimateWideScalars.Count;k++)
            {
                double percent = EstimateWideScalars[k];
                double addedCost = CalculateNewTotal(ContType.Percent, totalCost, percent);
                totalCost += addedCost;
                Factor factor = new Factor("est", "est", "name", percent, addedCost);
                Factors.Add(factor);
            } 


            return totalCost;
        }

        public List<Factor> GetFactors()
        {
           
            return Factors;
        }
      
        public double CalculateNewTotal(ContType type, double cbc, double percent, double lineItem = 0)
        {
         
            double added;
           
            if (type == 0)
            {
                added = lineItem;
              
            }
            else
            {
                added = (percent) * cbc;
              

            }
            


            return added;
        }
    }
}
