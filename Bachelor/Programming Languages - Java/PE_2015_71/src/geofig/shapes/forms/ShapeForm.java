package geofig.shapes.forms;

import java.awt.GridLayout;
import java.util.ArrayList;

import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextArea;
import javax.swing.JTextField;

public class ShapeForm extends JPanel {
	private static final long serialVersionUID = 1L;
	
	private JTextField name;
	private JTextArea description;
	
	public ShapeForm() {
		this.setLayout(new GridLayout(0, 2));
		this.add(new JLabel("Name:"));
		this.name = new JTextField();
		this.add(this.name);
		this.add(new JLabel("Description:"));
		this.description = new JTextArea();
		this.add(this.description);
	}
	
	public ArrayList<String> attributes() {
		ArrayList<String> result = new ArrayList<>();
		result.add(name.getText());
		result.add(description.getText());
		
		return result;
	}

}
