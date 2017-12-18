package rollBot;

public class Driver {

	public static void main(String[] args) {
		
//		if(args.length != 1){
//            System.out.println("Please enter the bots token as the first argument e.g java -jar thisjar.jar tokenhere");
//            return;
//        }
		
		RollBot rollbot = new RollBot(args);

	}

}
