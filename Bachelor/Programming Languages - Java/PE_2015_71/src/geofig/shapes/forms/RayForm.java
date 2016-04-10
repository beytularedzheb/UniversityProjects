package geofig.shapes.forms;

import java.util.ArrayList;

import javax.swing.JLabel;
import javax.swing.JTextField;

public class RayForm extends LineForm {
	private static final long serialVersionUID = 1L;

	private JTextField cX;
	private JTextField cY;
	private JTextField direction;
	
	public RayForm() {
		super();
		this.add(new JLabel("X:"));
		this.cX = new JTextField();
		this.add(this.cX);
		this.add(new JLabel("Y:"));
		this.cY = new JTextField();
		this.add(this.cY);
		this.add(new JLabel("Direction:"));
		this.direction = new JTextField();
		this.add(this.direction);
	}

	public ArrayList<String> attributes() {
		ArrayList<String> result = super.attributes();
		result.add(cX.getText());
		result.add(cY.getText());
		result.add(direction.getText());
		
		return result;
	}
}
