package geofig.shapes;

public class Prism extends Polyhedra {

	private String crossSection;
	
	public Prism() {

	}

	public Prism(String name, String description, String surfaceArea,
			int vertices, String crossSection) {
		super(name, description, surfaceArea, vertices);
		this.crossSection = crossSection;
	}
	
	public Prism(String[] attributes) {
		this(attributes[0], attributes[1], 
				attributes[2], 
				Integer.parseInt(attributes[3]),
				attributes[4]);
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(crossSection);
		
		return builder.toString();
	}

	public String getCrossSection() {
		return crossSection;
	}

	public void setCrossSection(String crossSection) {
		this.crossSection = crossSection;
	}
	
}
