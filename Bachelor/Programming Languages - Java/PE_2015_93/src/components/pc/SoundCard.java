package components.pc;

public class SoundCard extends WithoutMemory {

	private String channel; // 2.1, 5.1, 7.1, etc.
	
	public String getChannel() {
		return channel;
	}

	public void setChannel(String channel) {
		this.channel = channel;
	}

	public SoundCard() {
		
	}

	public SoundCard(String name, boolean primary, String channel) {
		super(name, primary);
		this.channel = channel;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		sb.append(this.channel);
				
		return sb.toString();
	}
	
}
