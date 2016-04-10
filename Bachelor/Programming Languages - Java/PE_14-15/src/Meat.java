
public class Meat extends Animal {
	
	private String color;

	public String getColor() {
		return color;
	}

	public void setColor(String color) {
		this.color = color;
	}
	
	public Meat() {
		
	}
	
	public Meat(String name, NutrientContent nutrientContent, float net,
			boolean gmo, String typeOfAnimal, String color) {
		super(name, nutrientContent, net, gmo, typeOfAnimal);
		this.color = color;
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(color);
		
		return builder.toString();
	}
}
