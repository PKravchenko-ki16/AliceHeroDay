namespace AliceHeroDay.Model.Data
{
    public class DataConnection
    {
        private static DataConnection instance;

        public string dataManagement { get; private set; }
        public string dataDialogueContext { get; private set; }
        public string dataHeroContext { get; private set; }
        public string dataVillainsContext { get; private set; }
        public string dataSuperHero { get; private set; }


        private DataConnection()
        {
            this.dataManagement = "../../../../dataManagement.json";
            this.dataDialogueContext = "../../../../dataDialogueContext.json";
            this.dataHeroContext = "../../../../dataHeroContext.json";
            this.dataVillainsContext = "../../../../dataVillainsContext.json";
            this.dataSuperHero = "../../../../dataSuperHero.json";
        }

        public static DataConnection getDataConnection()
        {
            if (instance == null)
                instance = new DataConnection();
            return instance;
        }
    }
}
