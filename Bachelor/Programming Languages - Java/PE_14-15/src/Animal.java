
public class Animal extends Eateable {

	private String typeOfAnimal;

	public String getTypeOfAnimal() {
		return typeOfAnimal;
	}

	public void setTypeOfAnimal(String typeOfAnimal) {
		this.typeOfAnimal = typeOfAnimal;
	}
	
	public Animal() {
		
	}
	
	public Animal(String name, NutrientContent nutrientContent, float net,
			boolean gmo, String typeOfAnimal) {
		super(name, nutrientContent, net, gmo);
		this.typeOfAnimal = typeOfAnimal;
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(typeOfAnimal);
		
		return builder.toString();
	}
}
