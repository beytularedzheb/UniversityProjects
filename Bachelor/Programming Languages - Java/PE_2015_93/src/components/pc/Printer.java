package components.pc;

public class Printer extends OutputDevice {

	private boolean monochrome;
	
	public boolean isMonochrome() {
		return monochrome;
	}

	public void setMonochrome(boolean monochrome) {
		this.monochrome = monochrome;
	}
	
	public Printer() {
		
	}

	public Printer(String name, boolean wired, String modalityOfOuput, 
			boolean monochrome) {
		super(name, wired, modalityOfOuput);
		this.monochrome = monochrome;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		if (this.monochrome) {
			sb.append("Monochrome");
		}
		else {
			sb.append("Not monochrome");
		}
		
		return sb.toString();
	}
	
}
