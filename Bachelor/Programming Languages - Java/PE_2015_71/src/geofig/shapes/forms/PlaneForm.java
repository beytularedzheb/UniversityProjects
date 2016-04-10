package geofig.shapes.forms;

import java.util.ArrayList;

import javax.swing.JLabel;
import javax.swing.JTextField;

public class PlaneForm extends ShapeForm {
	private static final long serialVersionUID = 1L;
	
	private JTextField area;

	public PlaneForm() {
		super();
		this.add(new JLabel("Area:"));
		this.area = new JTextField();
		this.add(this.area);
	}
	
	public ArrayList<String> attributes() {
		ArrayList<String> result = super.attributes();
		result.add(area.getText());
		
		return result;
	}
	
}
