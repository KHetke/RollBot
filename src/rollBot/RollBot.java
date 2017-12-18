package rollBot;

import sx.blah.discord.api.IDiscordClient;

public class RollBot {

	public RollBot(String [] args) {
		//IDiscordClient cli = BotUtils.getBuiltDiscordClient(args[0]);
		IDiscordClient cli = BotUtils.getBuiltDiscordClient("MjMzMDczODA3NTQyMTkwMDgx.DRfYSw.rJr3LPCegpnRFI_wIL8ieLeJyGc");
        /*
        // Commented out as you don't really want duplicate listeners unless you're intentionally writing your code 
        // like that.
        // Register a listener via the IListener interface
        cli.getDispatcher().registerListener(new IListener<MessageReceivedEvent>() {
            public void handle(MessageReceivedEvent event) {
                if(event.getMessage().getContent().startsWith(BotUtils.BOT_PREFIX + "test"))
                    BotUtils.sendMessage(event.getChannel(), "I am sending a message from an IListener listener");
            }
        });
        */

        // Register a listener via the EventSubscriber annotation which allows for organisation and delegation of events
        cli.getDispatcher().registerListener(new Events());

        // Only login after all events are registered otherwise some may be missed.
        cli.login();
	}
	
	
}
