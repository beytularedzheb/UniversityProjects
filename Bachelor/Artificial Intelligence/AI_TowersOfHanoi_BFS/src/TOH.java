import java.util.Collections;
import java.util.HashSet;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Queue;
import java.util.Scanner;
import java.util.Set;
import java.util.Stack;
import java.util.TreeMap;

public class TOH {

	/* 
	 * 1 1 1 - � ����� ����� �� ������� �� 1-�� �����
	 * 3 3 3 - � ����� ����� ������ �� �� ��������� �� 3-�� �����
	 * */
	
	public static void main(String args[]) {
		Scanner sc = new Scanner(System.in);
		int n = 3; //sc.nextInt(); // ���� �������
		int k = 3; //sc.nextInt(); // ���� ����
		
		// ��������� �� ��������� ���������
		Node source = readPegsConfiguration(k, n, sc);
		// ��������� �� �������� ���������
		Node target = readPegsConfiguration(k, n, sc);
		// �� ������� �� ���������� ������� � ��������� �� �����
		Set<Node> visited = new HashSet<>();
		try {
			minMovesToTarget(source, target, visited);
		} catch (Exception ex) {
			System.out.println("Exception = " + ex);
		}
	}

	private static void minMovesToTarget(Node source, Node target, Set<Node> visited) throws CloneNotSupportedException {
		// ���������� �� ������� � �������� - BFS
		Queue<Node> q = new LinkedList<>();
		// �������� �� �������� ���� � ��������
		q.add(source);
		Node current = source;
		while (!q.isEmpty()) {
			current = (Node) q.poll();
			if (current.equals(target)) { // ������ � �������
				break;
			}
			List<Node> neighbors = current.neighbors();
			if (neighbors.size() > 0) {
				for (Node n : neighbors) {
					if (!visited.contains(n)) {// ��� ������ �� � �������
											   // ������ �� � ��������
						q.offer(n);
						visited.add(n);
					}
				}
			}
		}
		// ����������� �� ��������� ��� ������ � �������
		if (current.equals(target)) {
			printOutput(current);
		}
	}

	private static Node readPegsConfiguration(int k, int n, Scanner sc) {
		Stack<Integer>[] initialState = new Stack[k];
		for (int i = 0; i < k; i++) {
			initialState[i] = new Stack<Integer>();
		}
		// ������ � �������� �.� � ����� �� ��������� ����������
		// � ��������� ���
		// ������ � ������, � ������ � ����������
		TreeMap<Integer, Integer> map = new TreeMap<Integer, Integer>(Collections.reverseOrder());
		for (int i = 0; i < n; i++) {
			map.put(i, sc.nextInt());
		}
		// prepare towers
		for (Map.Entry<Integer, Integer> entry : map.entrySet()) {
			initialState[entry.getValue() - 1].push(entry.getKey());
		}
		return new Node(initialState);
	}

	static void printOutput(Node target) {
		Stack<Move> stack = new Stack<>(); // ���������� ����, ��� ���� ������ �� ���������� 
										   // ���� �� �������� �� ������� ����
		while (target.parent != null) {
			stack.push(target.move);
			target = target.parent;
		}
		System.out.println("���� ������: " + stack.size());
		System.out.println("\nO�\t��");
		while (!stack.isEmpty()) {
			System.out.println(stack.pop().toString());
		}
	}

}