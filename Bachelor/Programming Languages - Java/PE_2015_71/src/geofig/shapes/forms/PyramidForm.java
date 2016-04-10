package geofig.shapes.forms;

import java.util.ArrayList;

import javax.swing.JLabel;
import javax.swing.JTextField;

public class PyramidForm extends PolyhedraForm {
	private static final long serialVersionUID = 1L;
	
	private JTextField base;
	
	public PyramidForm() {
		super();
		this.add(new JLabel("Base:"));
		this.base = new JTextField();
		this.add(this.base);
	}

	public ArrayList<String> attributes() {
		ArrayList<String> result = super.attributes();
		result.add(base.getText());
		
		return result;
	}
}
