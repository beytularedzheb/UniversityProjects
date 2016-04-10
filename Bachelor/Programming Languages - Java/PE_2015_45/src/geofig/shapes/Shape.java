package geofig.shapes;

public class Shape {

	private String name;
	private String description;
	
	public Shape() {

	}
	
	public Shape(String name, String description) {
		this.name = name;
		this.description = description;
	}
	
	public Shape(String[] attributes) {
		this(attributes[0], attributes[1]);
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append("\n").append(name).append(" | ");
		builder.append(description);
		
		return builder.toString();
	}
	
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

}
