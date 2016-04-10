package components.pc;

public class InputDevice extends External {

	private String modalityOfInput; // mechanical motion, audio, visual, etc.
	
	public String getModalityOfInput() {
		return modalityOfInput;
	}

	public void setModalityOfInput(String modalityOfInput) {
		this.modalityOfInput = modalityOfInput;
	}

	public InputDevice() {
		
	}

	public InputDevice(String name, boolean wired, String modalityOfInput) {
		super(name, wired);
		this.modalityOfInput = modalityOfInput;
	}

	@Override
	public String toString() {
		StringBuilder sb = new StringBuilder();
		sb.append(super.toString());
		sb.append(", ");		
		sb.append(this.modalityOfInput);
				
		return sb.toString();
	}
}
