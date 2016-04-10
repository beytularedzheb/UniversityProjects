package geofig.shapes;

public class Point extends Shape {

	private float abscissa;
	private float ordinate;
	
	public Point() {

	}
	
	public Point(String name, String description, float abscissa, float ordinate) {
		super(name, description);
		this.abscissa = abscissa;
		this.ordinate = ordinate;
	}
	
	public Point(String[] attributes) {
		this(attributes[0], attributes[1], 
				Float.parseFloat(attributes[2]),
				Float.parseFloat(attributes[3]));
	}

	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(abscissa).append(", ");
		builder.append(ordinate);
		
		return builder.toString();
	}
	
	public float getAbscissa() {
		return abscissa;
	}

	public void setAbscissa(float abscissa) {
		this.abscissa = abscissa;
	}

	public float getOrdinate() {
		return ordinate;
	}

	public void setOrdinate(float ordinate) {
		this.ordinate = ordinate;
	}

}
