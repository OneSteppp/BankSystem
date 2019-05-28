public class BankDemo {
	public static void Main(string [] args)
	{
		Bank bank = new Bank();
		bank.OpenAccount("ZhangRuiqian","ZRQ", "125422", 1000000);
		bank.OpenCreditAccount("Zhangruiqian","ZRQ", "125422", 0,100000);
		ATM atm = new ATM(bank);

        bool next = false;

        do
        {
            atm.Show("1:Deposit Card; 2:Credit Card");
            string op = atm.GetInput();
            if (op == "1")
            {
                atm.DepositTransaction();
            }
            else if (op == "2")
            {
                atm.CreditTransaction();
            }
            atm.Show("1:finish; 2:chose card");
            op = atm.GetInput();
            if (op == "1")
            {
                next = false;
            }
            else if (op == "2")
            {
                next = true;
            }
        } while (next);

        
        
	}
	
}
