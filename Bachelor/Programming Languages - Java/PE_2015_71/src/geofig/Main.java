package geofig;

public class Main {
	
	private static GUI gui;

	public static void main(String[] args) {
		// стартиране на приложението
		setGui(new GUI("√еометрични фигури"));
	}

	public static GUI getGui() {
		return gui;
	}

	public static void setGui(GUI gui) {
		Main.gui = gui;
	}

}
