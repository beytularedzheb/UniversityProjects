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
	 * 1 1 1 - и трите диска се намират на 1-ви пилон
	 * 3 3 3 - и трите диска трябва да се преместят на 3-ти пилон
	 * */
	
	public static void main(String args[]) {
		Scanner sc = new Scanner(System.in);
		int n = 3; //sc.nextInt(); // брой дискове
		int k = 3; //sc.nextInt(); // брой кули
		
		// прочитане на началното състояние
		Node source = readPegsConfiguration(k, n, sc);
		// прочитане на крайното състояние
		Node target = readPegsConfiguration(k, n, sc);
		// за следене на посетените върхове и избягване на цикли
		Set<Node> visited = new HashSet<>();
		try {
			minMovesToTarget(source, target, visited);
		} catch (Exception ex) {
			System.out.println("Exception = " + ex);
		}
	}

	private static void minMovesToTarget(Node source, Node target, Set<Node> visited) throws CloneNotSupportedException {
		// извършване на търсене в широчина - BFS
		Queue<Node> q = new LinkedList<>();
		// добавяне на началния връх в опашката
		q.add(source);
		Node current = source;
		while (!q.isEmpty()) {
			current = (Node) q.poll();
			if (current.equals(target)) { // върхът е намерен
				break;
			}
			List<Node> neighbors = current.neighbors();
			if (neighbors.size() > 0) {
				for (Node n : neighbors) {
					if (!visited.contains(n)) {// ако върхът не е посетен
											   // добавя се в опашката
						q.offer(n);
						visited.add(n);
					}
				}
			}
		}
		// отпечатване на резултата ако върхът е намерен
		if (current.equals(target)) {
			printOutput(current);
		}
	}

	private static Node readPegsConfiguration(int k, int n, Scanner sc) {
		Stack<Integer>[] initialState = new Stack[k];
		for (int i = 0; i < k; i++) {
			initialState[i] = new Stack<Integer>();
		}
		// четене и обръщане т.к е нужно да поставиме елементите
		// в намаляващ ред
		// дискът е ключът, а кулата е стойността
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
		Stack<Move> stack = new Stack<>(); // използваме стек, тъй като трябва да отпечатаме 
										   // пътя от началния до крайния връх
		while (target.parent != null) {
			stack.push(target.move);
			target = target.parent;
		}
		System.out.println("Брой стъпки: " + stack.size());
		System.out.println("\nOт\tНа");
		while (!stack.isEmpty()) {
			System.out.println(stack.pop().toString());
		}
	}

}