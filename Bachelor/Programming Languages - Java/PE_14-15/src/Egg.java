
public class Egg extends Animal {

	private boolean pasteurized;

	public boolean isPasteurized() {
		return pasteurized;
	}

	public void setPasteurized(boolean pasteurized) {
		this.pasteurized = pasteurized;
	}
	
	public Egg() {
		
	}
	
	public Egg(String name, NutrientContent nutrientContent, float net,
			boolean gmo, String typeOfAnimal, boolean pasteurized) {
		super(name, nutrientContent, net, gmo, typeOfAnimal);
		this.pasteurized = pasteurized;
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(pasteurized);
		
		return builder.toString();
	}
}
