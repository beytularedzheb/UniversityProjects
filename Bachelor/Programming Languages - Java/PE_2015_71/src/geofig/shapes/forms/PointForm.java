package geofig.shapes.forms;

import java.util.ArrayList;

import javax.swing.JLabel;
import javax.swing.JTextField;

public class PointForm extends ShapeForm {
	private static final long serialVersionUID = 1L;

	private JTextField abscissa;
	private JTextField ordinate;
	
	public PointForm() {
		super();
		this.add(new JLabel("Abscissa:"));
		this.abscissa = new JTextField();
		this.add(this.abscissa);
		this.add(new JLabel("Ordinate:"));
		this.ordinate = new JTextField();
		this.add(this.ordinate);
	}
	
	public ArrayList<String> attributes() {	
		ArrayList<String> result = super.attributes();
		result.add(abscissa.getText());
		result.add(ordinate.getText());
		
		return result;
	}

}
