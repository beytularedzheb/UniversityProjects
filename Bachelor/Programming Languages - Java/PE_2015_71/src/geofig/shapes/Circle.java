package geofig.shapes;

// класът Circle наследява класът Curve
public class Circle extends Curve {

	// периметър на окръжността;
	private float circumference;
	
	// конструкторът по подразбиране
	public Circle() {

	}

	// инициализиращ конструктор
	public Circle(String name, String description, String area,
			float majorAxes, float minorAxes, float circumference) {
		// извикване конструктора на класът-родител
		super(name, description, area, majorAxes, minorAxes);
		// инициализиране на периметъра
		this.circumference = circumference;
	}
	
	// конструктор, който приема масив от String-ове, който съдържа
	// стойностите на полетата на класа
	public Circle(String[] attributes) {
		// извикване на инициализиращия конструктор на класа
		this(attributes[0], attributes[1], attributes[2],
				Float.parseFloat(attributes[3]),
				Float.parseFloat(attributes[4]),
				Float.parseFloat(attributes[5]));
	}

	// предефиниране на функцията toString()
	// връща String, съдържащ стойностите на всичките полета на класа
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(circumference);
		
		return builder.toString();
	}
	
	// getter на circumference
	public float getCircumference() {
		return circumference;
	}

	// setter на circumference
	public void setCircumference(float circumference) {
		this.circumference = circumference;
	}

}
