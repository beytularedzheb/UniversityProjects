
public class Foodstuff {
	
	private String name;
	private NutrientContent nutrientContent;
	private float net;
	
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public NutrientContent getNutrientContent() {
		return nutrientContent;
	}
	public void setNutrientContent(NutrientContent nutrientContent) {
		this.nutrientContent = nutrientContent;
	}
	public float getNet() {
		return net;
	}
	public void setNet(float net) {
		this.net = net;
	}
	
	public Foodstuff() {
		
	}
		
	public Foodstuff(String name, NutrientContent nutrientContent, float net) {
		super();
		this.name = name;
		this.nutrientContent = nutrientContent;
		this.net = net;
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append("\n").append(name).append(" | ");
		builder.append(nutrientContent).append(" | ");
		builder.append(net);
		
		return builder.toString();
	}
}
