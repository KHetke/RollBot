package rollBot;

import sx.blah.discord.api.events.EventSubscriber;
import sx.blah.discord.handle.impl.events.guild.channel.message.MessageReceivedEvent;

public class Events {

	
	@EventSubscriber
	public void onMessageReceived(MessageReceivedEvent event){	
		  
		String[] argArray = event.getMessage().getContent().split(" ", 2);
		  
		if(argArray.length == 0 || !argArray[0].startsWith(BotUtils.BOT_PREFIX)) {
			return;
		}
		  
		argArray[0] = argArray[0].substring(1);
		  
		switch(argArray[0]) {
		case "test":
			testCommand(event);
			break;
			
		case "roll":
			rollCommand(event, argArray[1]);
			break;
			
		case "r":
			
			break;
		  	
		}
	}
	
	private void rollCommand(MessageReceivedEvent event, String args) {
		int rollValue = Roll.roll(args);
		BotUtils.sendMessage(event.getChannel(), "The roll is " + rollValue);
	}
	
	private void testCommand(MessageReceivedEvent event) {
		int rollValue = Roll.roll("1d5d4+2d4");
		BotUtils.sendMessage(event.getChannel(), "The test roll is " + rollValue);
	}
	
}