package components.pc;

public class Monitor extends OutputDevice {

	private int numberOfColors;
	
	public int getNumberOfColors() {
		return numberOfColors;
	}

	public void setNumberOfColors(int numberOfColors) {
		this.numberOfColors = numberOfColors;
	}
	
	public Monitor() {
		
	}

	public Monitor(String name, boolean wired, String modalityOfOuput, 
			int numberOfColors) {
		super(name, wired, modalityOfOuput);
		this.numberOfColors = numberOfColors;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		sb.append(this.numberOfColors);
				
		return sb.toString();
	}

}
