import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Stack;


class Node implements Cloneable {
		// ����
		Stack<Integer>[] state = null;
		Node parent = null;
		Move move = null; // ��� ����������� �� ��������� ����

		public Node(Stack<Integer>[] st) {
			state = st;
		}

		@Override
		protected Node clone() throws CloneNotSupportedException {
			Stack<Integer>[] cloneStacks = new Stack[state.length];
			for (int i = 0; i < state.length; i++) {
				cloneStacks[i] = (Stack<Integer>) state[i].clone();
			}
			Node clone = new Node(cloneStacks);
			return clone;
		}

		// ����� �� ��������� �������
		public List<Node> neighbors() throws CloneNotSupportedException {
			List<Node> neighbors = new ArrayList<>();
			int k = state.length;
			for (int i = 0; i < k; i++) {
				for (int j = 0; j < k; j++) {
					if (i != j && !state[i].isEmpty()) {
						// ����� � �� ��������� �� �� �������� "��������"
						// Hint - � java �������� �� �� mutable � �� ���������� ������
						Node child = this.clone();
						// �����������
						if (canWeMove(child.state[i], child.state[j])) {
							child.state[j].push(child.state[i].pop());
							child.parent = this;
							child.move = new Move(i, j);
							neighbors.add(child);
						}
					}
				}
			}
			return neighbors;
		}

		public boolean canWeMove(Stack<Integer> fromTower, Stack<Integer> toTower) {
			boolean answer = false;
			if (toTower.isEmpty()) {// ��� �������� ���� � "������" - 
									// ���� �� ��������� �����
				return true;
			}
			int toDisc = (int) toTower.peek();
			int fromDisc = (int) fromTower.peek();
			if (fromDisc < toDisc) { // ���� �� ��������� ���� ��-����� ����
				answer = true;
			}
			return answer;
		}

		@Override
		public int hashCode() {
			int hash = 7;
			return hash;
		}

		@Override
		public boolean equals(Object obj) {
			if (obj == null) {
				return false;
			}
			if (getClass() != obj.getClass()) {
				return false;
			}
			final Node other = (Node) obj;
			if (!Arrays.deepEquals(this.state, other.state)) {
				return false;
			}
			return true;
		}

	}