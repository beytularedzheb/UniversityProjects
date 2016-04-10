
public class Fish extends Animal {

	private String fishType;

	public String getFishType() {
		return fishType;
	}

	public void setFishType(String fishType) {
		this.fishType = fishType;
	}
	
	public Fish() {
		
	}
	
	public Fish(String name, NutrientContent nutrientContent, float net,
			boolean gmo, String typeOfAnimal, String fishType) {
		super(name, nutrientContent, net, gmo, typeOfAnimal);
		this.fishType = fishType;
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(fishType);
		
		return builder.toString();
	}
}
