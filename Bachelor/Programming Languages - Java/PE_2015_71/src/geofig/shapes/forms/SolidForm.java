package geofig.shapes.forms;

import java.util.ArrayList;

import javax.swing.JLabel;
import javax.swing.JTextField;

public class SolidForm extends ShapeForm {
	private static final long serialVersionUID = 1L;
	
	private JTextField surfaceArea;
	
	public SolidForm() {
		super();
		this.add(new JLabel("Surface area:"));
		this.surfaceArea = new JTextField();
		this.add(this.surfaceArea);
	}
	
	public ArrayList<String> attributes() {
		ArrayList<String> result = super.attributes();
		result.add(surfaceArea.getText());
		
		return result;
	}

}
