package components.pc;

public class MultifunctionPrinter extends IODevice {

	private String includedDevices;
	
	public String getIncludedDevices() {
		return includedDevices;
	}

	public void setIncludedDevices(String includedDevices) {
		this.includedDevices = includedDevices;
	}

	public MultifunctionPrinter() {
		
	}

	public MultifunctionPrinter(String name, boolean wired, 
			String modalityOfIO, String includedDevices) {
		super(name, wired, modalityOfIO);
		this.includedDevices = includedDevices;
	}
	
	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");
		sb.append(this.includedDevices);
				
		return sb.toString();
	}
	
}
