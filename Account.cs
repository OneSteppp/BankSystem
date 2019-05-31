
public class BadCashException : System.Exception
{
    public BadCashException(string message)
        : base(message) { }
}
public class Account {
    public string name { set; get; }
    public double money { set; get; }//decimal money;
    public string id { set; get; }
    public string pwd { set; get; }
	


    public Account(string name, string id, string pwd, double money )
	{
        //if( money < 0 ) throw new System.Exception("´æÇ®Êý²»ÄÜÐ¡ÓÚ0£¡");
        this.name = name;
		this.id = id;
		this.pwd = pwd;
		this.money = money;
	}
	
	public virtual bool SaveMoney( double money)
	{
		if( money < 0 ) return false;  //ÎÀÓï¾ä		
		this.money += money;
		return true;		
	}
	
	public virtual bool WithdrawMoney( double money)
	{
        System.Random rnd = new System.Random();
		if( this.money >= money )
		{
            if (rnd.Next(3) < 1)
            {
                this.money -= money;
                return true;
            }
            else
                throw new BadCashException("´æÔÚÆÆËðµÄ³®Æ±");
		}
		return false;
	}
	
	public bool IsMatch( string id, string pwd )
	{
		return id==this.id && pwd==this.pwd;
	}	
}
public class CreditCardAccount : Account
{
    public double CreditLimit { set; get; }
    public CreditCardAccount(string name, string id, string pwd, double money, double limit):base(name,id,pwd,money)
    {
        CreditLimit = limit;
    }
    public override bool WithdrawMoney(double money)
    {
        System.Random rnd = new System.Random();
        if (money > CreditLimit) return false;
        else
        {
            if (rnd.Next(3) < 1)
            {
                CreditLimit -= money;
                return true;
            }
            else
                throw new BadCashException("´æÔÚÆÆËðµÄ³®Æ±");
        }
    }
    public override bool SaveMoney(double money)
    {
        if (money < 0) return false;  //ÎÀÓï¾ä		
        this.CreditLimit += money;
        return true;
    }
}













