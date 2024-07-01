namespace CTG.ContService
{
    public class ContingencyCalculator
    {

        public ContingencyCalculator()
        {
                
        }

        public string Calculate(ContType type,double cbc,double percent, double lineItem=0)
        {
            double total;
            double added;
            double percentOfTotal;
            if (type ==0)
            {
                added=lineItem;
                percentOfTotal =  lineItem/(cbc + lineItem);
            }
            else
            {
                added = ((percent) / (1 - percent))*cbc;
                percentOfTotal = percent;

            }
            total = cbc + added;


            return "Percent of total =" + percentOfTotal + ", Ammount added=" + added+ ", new Total= " + total;
        }
    }
}
