namespace CTG.ContService
{
    public class Factor(string fam, string scope, string name, double percent, double ammount)
    {
        // IE contingency or Escalation
        public string Family { get; set; } = fam;

        //IE tab specific or estimate wide 
        public string Scope { get; set; } = scope;
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = name;
        /// <summary>
        /// 
        /// </summary>
            public double Percent { get; set; } = percent;
        /// <summary>
        /// 
        /// </summary>
            public double Ammount { get; set; } = ammount;
    }
}
