package components.pc;

public class OutputDevice extends External {

	private String modalityOfOutput; // visual, audio, tactile, etc.
	
	public String getModalityOfOutput() {
		return modalityOfOutput;
	}

	public void setModalityOfOutput(String modalityOfOutput) {
		this.modalityOfOutput = modalityOfOutput;
	}
	
	public OutputDevice() {
		
	}

	public OutputDevice(String name, boolean wired, String modalityOfOutput) {
		super(name, wired);
		this.modalityOfOutput = modalityOfOutput;
	}
	
	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");		
		sb.append(this.modalityOfOutput);
				
		return sb.toString();
	}

}
