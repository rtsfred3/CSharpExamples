namespace DojoSurveyModels{
    public class LocalDictionary{
        public string id{ get; set; }
        public string name{ get; set; }

        public LocalDictionary(string _id, string _name){
            this.id = _id;
            this.name = _name;
        }
    }
}