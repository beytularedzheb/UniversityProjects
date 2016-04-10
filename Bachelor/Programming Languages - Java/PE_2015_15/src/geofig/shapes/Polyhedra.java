package geofig.shapes;

public class Polyhedra extends Solid {

	private int vertices;
	
	public Polyhedra() {

	}

	public Polyhedra(String name, String description, String surfaceArea, 
			int vertices) {
		super(name, description, surfaceArea);
		this.vertices = vertices;
	}
	
	public Polyhedra(String[] attributes) {
		this(attributes[0], attributes[1], 
				attributes[2], 
				Integer.parseInt(attributes[3]));
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(vertices);
		
		return builder.toString();
	}
	
	public int getVertices() {
		return vertices;
	}

	public void setVertices(int vertices) {
		this.vertices = vertices;
	}

}
