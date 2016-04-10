
class Move {
	int towerFrom, towerTo;

	public Move(int f, int t) {
		towerFrom = f + 1;
		towerTo = t + 1;
	}

	@Override
	public String toString() {
		return towerFrom + "\t" + towerTo;
	}
}
