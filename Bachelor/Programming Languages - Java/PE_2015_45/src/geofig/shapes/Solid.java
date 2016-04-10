package geofig.shapes;

public class Solid extends Shape {

	private String surfaceArea;

	public Solid() {
		
	}
	
	public Solid(String name, String description, String surfaceArea) {
		super(name, description);
		this.surfaceArea = surfaceArea;
	}
	
	public Solid(String[] attributes) {
		this(attributes[0], attributes[1], attributes[2]);
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(surfaceArea);
		
		return builder.toString();
	}
	
	public String getSurfaceArea() {
		return surfaceArea;
	}

	public void setSurfaceArea(String surfaceArea) {
		this.surfaceArea = surfaceArea;
	}
	
}
