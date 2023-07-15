namespace HowToStoreVariables.Constants
{
    public class Variables
    {
        public string First { get; set; }

        private string _second;
        public string Second { get => _second; set => _second ??= value; }

        private string _third;
        public string Third { get => _third; set => _third = _third == null ? value : throw new Exception($"Cannot rewrite constant, class name: {nameof(Variables)}"); }
        //public string Third
        //{
        //    get => _third;
        //    set
        //    {
        //        if (_third == null)
        //        {
        //            _third = value;
        //        }
        //        else
        //        {
        //            throw new Exception($"Cannot rewrite constant, class name: {nameof(Variables)}");
        //        }
        //    }
        //}
    }
}
