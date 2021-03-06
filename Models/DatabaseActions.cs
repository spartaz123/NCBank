using MongoDB.Bson;
using MongoDB.Driver;

namespace NCBank.Models {
    public static class DBInterface {
        static private IMongoDatabase db = new MongoClient().GetDatabase("bankNC");
        static internal IMongoCollection<BankCustomer> cust = db.GetCollection<BankCustomer>("customers");
        static internal IMongoCollection<Sessions> sess = db.GetCollection<Sessions>("sessions");
        static internal IMongoCollection<CustomerBalance> bal = db.GetCollection<CustomerBalance>("balance");
        static public IMongoCollection<Transaction> tran = db.GetCollection<Transaction>("transactions");
    }
}