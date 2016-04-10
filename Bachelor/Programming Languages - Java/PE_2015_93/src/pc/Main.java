package pc;

public class Main {


	private static GUI gui;

	public static void main(String[] args) {
		setGui(new GUI("Computer components"));
	}

	public static GUI getGui() {
		return gui;
	}

	public static void setGui(GUI gui) {
		Main.gui = gui;
	}

}
