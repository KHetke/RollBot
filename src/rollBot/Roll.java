package rollBot;

import java.util.Random;
import java.util.regex.Pattern;

public class Roll {
	
	public static int roll(String commandParameters) {
		
		/* Settings */
        String addChar = "+";
        String dieChar = "d";
        /* ******** */
        
		int rollValue = 0;
		
		commandParameters = commandParameters.replace(" ", ""); //Remove white space
        
		String[] dieParameters = commandParameters.split(Pattern.quote(addChar));
		

		for (int i = 0; i < dieParameters.length; i++) //For every dieRolls index position, do the following...
        {
			String[] rollParameters = dieParameters[i].split(Pattern.quote(dieChar));
			if (2 <= rollParameters.length) {
				for (int j = 0; j < Integer.parseInt(rollParameters[0]); j++) // Loop the number of times specified in index 1 of roll
	            {
					for (int k = 1; k < rollParameters.length; k++)
					{
						Random r = new Random();
		                rollValue += r.nextInt(Integer.parseInt(rollParameters[k])) + 1;
					}
	            }
			}
			if (1 == rollParameters.length) {
				rollValue += Integer.parseInt(rollParameters[0]);
			}
        }
		
		return rollValue;
	}

}
