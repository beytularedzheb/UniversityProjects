package components.pc;

public class IODevice extends External {

	private String modalityOfIO;
	
	public String getModalityOfIO() {
		return modalityOfIO;
	}

	public void setModalityOfIO(String modalityOfIO) {
		this.modalityOfIO = modalityOfIO;
	}

	public IODevice() {
		
	}

	public IODevice(String name, boolean wired, String modalityOfIO) {
		super(name, wired);
		this.modalityOfIO = modalityOfIO;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");		
		sb.append(this.modalityOfIO);
				
		return sb.toString();
	}
}
