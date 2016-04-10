
public class Distilled extends AlcoholicBeverage {

	private String aroma;

	public String getAroma() {
		return aroma;
	}

	public void setAroma(String aroma) {
		this.aroma = aroma;
	}
	
	public Distilled() {
		
	}
	
	public Distilled(String name, NutrientContent nutrientContent, float net,
			boolean natural, float alcoholByVolume, String aroma) {
		super(name, nutrientContent, net, natural, alcoholByVolume);
		this.aroma = aroma;
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(super.toString()).append(" | ");
		builder.append(aroma);
		
		return builder.toString();
	}
}
