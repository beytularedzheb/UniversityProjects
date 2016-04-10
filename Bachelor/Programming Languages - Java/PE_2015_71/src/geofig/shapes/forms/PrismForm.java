package geofig.shapes.forms;

import java.util.ArrayList;

import javax.swing.JLabel;
import javax.swing.JTextField;

public class PrismForm extends PolyhedraForm {
	private static final long serialVersionUID = 1L;

	private JTextField crossSection;
	
	public PrismForm() {
		super();
		this.add(new JLabel("Cross section:"));
		this.crossSection = new JTextField();
		this.add(this.crossSection);
	}
	
	public ArrayList<String> attributes() {
		ArrayList<String> result = super.attributes();
		result.add(crossSection.getText());
		
		return result;
	}
}
