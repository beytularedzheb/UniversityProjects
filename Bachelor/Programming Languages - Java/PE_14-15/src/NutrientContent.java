
public class NutrientContent {
	
	private float water;
	private float proteins;
	private float fat;
	private float carbonhydrates;
	private float calories;
	
	public float getWater() {
		return water;
	}
	public void setWater(float water) {
		this.water = water;
	}
	public float getProteins() {
		return proteins;
	}
	public void setProteins(float proteins) {
		this.proteins = proteins;
	}
	public float getFat() {
		return fat;
	}
	public void setFat(float fat) {
		this.fat = fat;
	}
	public float getCarbonhydrates() {
		return carbonhydrates;
	}
	public void setCarbonhydrates(float carbonhydrates) {
		this.carbonhydrates = carbonhydrates;
	}
	public float getCalories() {
		return calories;
	}
	public void setCalories(float calories) {
		this.calories = calories;
	}
	
	public NutrientContent() {
		
	}
	
	public NutrientContent(float water, float proteins, float fat,
			float carbonhydrates, float calories) {
		super();
		this.water = water;
		this.proteins = proteins;
		this.fat = fat;
		this.carbonhydrates = carbonhydrates;
		this.calories = calories;
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(water).append("%, ");
		builder.append(proteins).append("g, ");
		builder.append(fat).append("g, ");
		builder.append(carbonhydrates).append("g, ");
		builder.append(calories).append("kcal");
		
		return builder.toString();
	}
}
