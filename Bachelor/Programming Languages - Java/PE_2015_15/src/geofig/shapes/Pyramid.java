package geofig.shapes;

public class Pyramid extends Polyhedra {

	private String base;
	
	public Pyramid() {

	}

	public Pyramid(String name, String description, String surfaceArea,
			int vertices, String base) {
		super(name, description, surfaceArea, vertices);
		this.base = base;
	}
	
	public Pyramid(String[] attributes) {
		this(attributes[0], attributes[1], 
				attributes[2], 
				Integer.parseInt(attributes[3]),
				attributes[4]);
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(base);
		
		return builder.toString();
	}

	public String getBase() {
		return base;
	}

	public void setBase(String base) {
		this.base = base;
	}
	
}
