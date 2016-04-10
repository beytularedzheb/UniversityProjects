package geofig.shapes.forms;

import java.util.ArrayList;

import javax.swing.JLabel;
import javax.swing.JTextField;

public class CurveForm extends PlaneForm {
	private static final long serialVersionUID = 1L;
	
	private JTextField majorAxes;
	private JTextField minorAxes;
	
	public CurveForm() {
		super();
		this.add(new JLabel("Major axes:"));
		this.majorAxes = new JTextField();
		this.add(this.majorAxes);
		this.add(new JLabel("Minor axes:"));
		this.minorAxes = new JTextField();
		this.add(this.minorAxes);
	}

	public ArrayList<String> attributes() {	
		ArrayList<String> result = super.attributes();
		result.add(majorAxes.getText());
		result.add(minorAxes.getText());
		
		return result;
	}
}
