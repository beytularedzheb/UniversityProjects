package geofig;

import java.awt.BorderLayout;
import java.awt.Component;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

import geofig.shapes.*;
import geofig.shapes.forms.*;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTabbedPane;


public class GUI {

	// прозорецът на програмата
	private JFrame frame;
	// панелът с табовете - за избор на клас
	private JTabbedPane tabbedPane;
	
	// брояч на добавените елементи в масива
	private int indexCounter = 0;
	// размер на масива
	private int length;
	// масивът с обектите
	private Shape[] shapes;
	
	// конструктор
	public GUI(String title) {
		try {
			// показване на диалог за въвеждане на размера на масива
			// т.к диалогът връща String - конвертираме го в число
			length = Integer.parseUnsignedInt(JOptionPane.showInputDialog(frame, "Size of the array is?"));
		}
		catch(Exception ex) {
			// ако потребителят не е въвел число или въобще не е въвел нищо
			// показване на диалог със съответната информация
			JOptionPane.showMessageDialog(frame, "Invalid number!");
		}
		
		// ако числото, което е въвел е по-голям от 0
		if (length > 0) {
			// създаване на масива
			shapes = new Shape[length];
			// създаване и добавяне на нужните панели в tabbedPane
			initTabbedPane();
			
			// прозорецът да ползва ресурсите на Java за визуализация
			JFrame.setDefaultLookAndFeelDecorated(true);
			// създаване на прозореца
			frame = new JFrame(title);
			// при избор на Х в горния-десен ъгъл да се спира приложението
			frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
			// задаване типа на подреждане на елементите в прозореца - BorderLayout
			frame.setLayout(new BorderLayout());
			
			// добавяне на tabbedPane в центъра на прозореца
			frame.add(tabbedPane, BorderLayout.CENTER);
			
			// създаване на панел, който ще съдържа двата бутона:
			// - добавяне на обекта в масива
			// - печатане на масива в конзолата
			JPanel panel = new JPanel();
			// създаване на бутона за добавяне
			JButton btnAdd = new JButton("Add");
			// добавяне на слушател
			btnAdd.addActionListener(new ActionListener() {
				// изпълнява се само при кликване на бутона
				@Override
				public void actionPerformed(ActionEvent e) {
					try {
						// ако има място в масива
						if (indexCounter < shapes.length) {
							// добавяне на обекта в масива
				        	boolean isAdded = addItem(tabbedPane.getSelectedComponent(), 
				        			tabbedPane.getTitleAt(tabbedPane.getSelectedIndex()));
							// ако НЕ е добавен успешно
				        	if (!isAdded) {
								// извеждане на съобщение
				        		JOptionPane.showMessageDialog(frame, "Please fill out all fields!");
				        	}
				        	else {
				        		JOptionPane.showMessageDialog(frame, "Added!");
				        	}
						}
						else {
							// ако няма място в масива - извеждане на съобщение
							JOptionPane.showMessageDialog(frame, "Array is full!");
						}
					}
					catch(Exception ex) {
						// ако вместо число се въведе текст се извежда съобщение за грешка
						JOptionPane.showMessageDialog(frame, "Please enter correct information!");
					}
				}
			});
			// добавяне на бутона в панела
			panel.add(btnAdd);
			// създаване на бутона за печатане
			JButton btnPrint = new JButton("Print to console");
			// добавяне на слушател
			btnPrint.addActionListener(new ActionListener() {
				// изпълнява се само при кликване на бутона
				@Override
				public void actionPerformed(ActionEvent e) {
					// с цикъл for обхождаме масива и извеждаме обектите в него
					for (Shape s : shapes) {
						if (s != null) {
							System.out.print(s.toString());
						}
					}
				}
			});
			// добавяне на бутона в панела
			panel.add(btnPrint);
			// добавяне на панела в прозореца
			frame.add(panel, BorderLayout.SOUTH);
			
			// пакетиране на компонентите на прозореца
			frame.pack();
			// задаване размера на прозореца
			frame.setSize(500, 250);
			// да не може да се оразмерява - прозорецът
			frame.setResizable(false);
			// да се появява в центъра на екрана на монитора
			frame.setLocationRelativeTo(null);
			// прозорецът да е видим
	        frame.setVisible(true);
		}
		else {
			JOptionPane.showMessageDialog(frame, "Please enter a number bigger than zero!");
		}
	}
	
	private void initTabbedPane() {
		// създаване на панела с табовете
		tabbedPane = new JTabbedPane();
		
		// добавяне на панелите
		tabbedPane.add(Shapes.CIRCLE, new CircleForm());
		tabbedPane.add(Shapes.COMPLEX, new ComplexForm());
		tabbedPane.add(Shapes.CONCAVE, new ConcaveForm());
		tabbedPane.add(Shapes.CONE, new ConeForm());
		tabbedPane.add(Shapes.CUBE, new CubeForm());
		tabbedPane.add(Shapes.CURVE, new CurveForm());
		tabbedPane.add(Shapes.CYLINDER, new CylinderForm());
		tabbedPane.add(Shapes.ELLIPSE, new EllipseForm());
		tabbedPane.add(Shapes.IRREGULAR_POLYGON, new IrregularPolygonForm());
		tabbedPane.add(Shapes.LINE, new LineForm());
		
		tabbedPane.add(Shapes.LINE_SEGMENT, new LineSegmentForm());
		tabbedPane.add(Shapes.NON_POLYHEDRA, new NonPolyhedraForm());
		tabbedPane.add(Shapes.PLANE, new PlaneForm());
		tabbedPane.add(Shapes.PLATONIC_SOLID, new PlatonicSolidForm());
		tabbedPane.add(Shapes.POINT, new PointForm());
		tabbedPane.add(Shapes.POLYGON, new PolygonForm());
		tabbedPane.add(Shapes.POLYHEDRA, new PolyhedraForm());
		tabbedPane.add(Shapes.PRISM, new PrismForm());
		tabbedPane.add(Shapes.PYRAMID, new PyramidForm());
		tabbedPane.add(Shapes.RAY, new RayForm());
		
		tabbedPane.add(Shapes.REGULAR_POLYGON, new RegularPolygonForm());
		tabbedPane.add(Shapes.SHAPE, new ShapeForm());
		tabbedPane.add(Shapes.SOLID, new SolidForm());
		tabbedPane.add(Shapes.SPHERE, new SphereForm());
		tabbedPane.add(Shapes.TORUS, new TorusForm());
	}

	private boolean addItem(Component selectedTab, String title) {
		ArrayList<String> attr = null;		
		int oldIndex = indexCounter;
		
		// намиране на избрания клас, извличане на данните, въведени
		// в панела и предаване на тези данни в конструктора на обекта за добавяне.
		// Съответният клас се грижи за тяхното конвертиране в нужния тип от String.
		// Ако има празно поле - обектът не се добавя в масива
		switch (title) {
		case Shapes.CIRCLE:
			attr = ((CircleForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Circle(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.COMPLEX:
			attr = ((ComplexForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Complex(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.CONCAVE:
			attr = ((ConcaveForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Concave(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.CONE:
			attr = ((ConeForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Cone(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.CUBE:
			attr = ((CubeForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Cube(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.CURVE:
			attr = ((CurveForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Curve(attr.toArray(new String[attr.size()]));
			break;	
		case Shapes.CYLINDER:
			attr = ((CylinderForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Cylinder(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.ELLIPSE:
			attr = ((EllipseForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Ellipse(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.IRREGULAR_POLYGON:
			attr = ((IrregularPolygonForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new IrregularPolygon(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.LINE:
			attr = ((LineForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Line(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.LINE_SEGMENT:
			attr = ((LineSegmentForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new LineSegment(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.NON_POLYHEDRA:
			attr = ((NonPolyhedraForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new NonPolyhedra(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.PLANE:
			attr = ((PlaneForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Plane(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.PLATONIC_SOLID:
			attr = ((PlatonicSolidForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new PlatonicSolid(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.POINT:
			attr = ((PointForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Point(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.POLYGON:
			attr = ((PolygonForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Polygon(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.POLYHEDRA:
			attr = ((PolyhedraForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Polyhedra(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.PRISM:
			attr = ((PrismForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Prism(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.PYRAMID:
			attr = ((PyramidForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Pyramid(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.RAY:
			attr = ((RayForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Ray(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.REGULAR_POLYGON:
			attr = ((RegularPolygonForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new RegularPolygon(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.SHAPE:
			attr = ((ShapeForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Shape(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.SOLID:
			attr = ((SolidForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Solid(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.SPHERE:
			attr = ((SphereForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Sphere(attr.toArray(new String[attr.size()]));
			break;
		case Shapes.TORUS:
			attr = ((TorusForm)selectedTab).attributes();
			if (!containsEmptyValue(attr))
				shapes[indexCounter] = new Torus(attr.toArray(new String[attr.size()]));
			break;
		default:
			System.out.println("\"" + title + "\" is invalid name!");
			break;
		}
		
		
		if (shapes[oldIndex] == null) {
			return false;
		}

		indexCounter++;
		
		return true;
	}
	
	// фунцкия за проверка дали има празен елемент в списъка list
	private boolean containsEmptyValue(ArrayList<String> list) {		
		for (String item : list) {
			if (null == item || item.isEmpty()) {
				return true;
			}
		}
		
		return false;
	}
}
