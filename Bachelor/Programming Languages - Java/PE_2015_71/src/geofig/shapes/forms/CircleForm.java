package geofig.shapes.forms;

import java.util.ArrayList;

import javax.swing.JLabel;
import javax.swing.JTextField;

// класът CircleForm наследява класът CurveForm
public class CircleForm extends CurveForm {
	private static final long serialVersionUID = 1L;
	
	// текстово поле, в което ще се въвежда 
	// периметъра на окръжност
	private JTextField circumference;
	
	// конструкторът на класа
	public CircleForm() {
		// извикване конструктора на класът-родител (наследеният клас)
		super();
		// добавяне на етикет в панела
		this.add(new JLabel("Circumference:"));
		// създаване на текстовото поле
		this.circumference = new JTextField();
		// добавяне на текстовото поле в панела
		this.add(this.circumference);
	}
	
	// функция, която връща стойностите на текстовите полета в панела
	public ArrayList<String> attributes() {
		ArrayList<String> result = super.attributes();
		result.add(circumference.getText());
		
		return result;
	}
}
