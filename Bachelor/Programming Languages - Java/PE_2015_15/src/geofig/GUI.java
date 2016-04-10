package geofig;

import geofig.shapes.*;

import java.awt.BorderLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FilenameFilter;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Scanner;

import javax.swing.JButton;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;


public class GUI implements ActionListener {
		
	private final String SPLITTER = ":";
	
	private File[] files;
	private JTextArea taContent;
	private JButton btnFile;
	private JButton btnShow;
	private JFileChooser fc;
	private JFrame frame;
	
	private LinkedList<Shape> shapeList;
	private int numberOfAttr;
	
	public GUI(String title) {

		shapeList = new LinkedList<>();
		
		JFrame.setDefaultLookAndFeelDecorated(true);
		frame = new JFrame(title);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(new BorderLayout());
		
		fc = new JFileChooser();
		fc.setCurrentDirectory(new java.io.File("."));
	    fc.setDialogTitle("Изберете директория");
	    fc.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
	    fc.setAcceptAllFileFilterUsed(false);
		
		
		/***********************************************************************/
		JPanel pnlButtons = new JPanel(new GridLayout(0, 2));
		
		btnFile = new JButton("Въвеждане на данни от файл");
		btnFile.addActionListener(this);
		pnlButtons.add(btnFile);
        
        btnShow = new JButton("Покажи");
        btnShow.addActionListener(this);
        btnShow.setEnabled(false);
        pnlButtons.add(btnShow);
              
        frame.getContentPane().add(pnlButtons, BorderLayout.PAGE_START);
        /***********************************************************************/
        
        
        /***********************************************************************/
        JPanel pnlContent = new JPanel(new BorderLayout());
        
        taContent = new JTextArea();
        
        JScrollPane scroll = new JScrollPane (taContent, 
        	JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED, JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);
        
        pnlContent.add(scroll, BorderLayout.CENTER);
        
        frame.getContentPane().add(pnlContent, BorderLayout.CENTER);
        /***********************************************************************/
        
               
		frame.pack();
		frame.setSize(500, 500);
		frame.setResizable(false);
		frame.setLocationRelativeTo(null);
        frame.setVisible(true);
	}
	
	private void readFiles() throws Exception {
		shapeList.clear();
		
		for (File file : files) {
			ArrayList<String[]> objectsAttr = getAttributes(file);
			for (String[] item : objectsAttr) {
					
				String fileName = file.getName().substring(0, file.getName().
						length() - ".txt".length()).toLowerCase();
				
				switch (fileName) {
				case Shapes.CIRCLE:
					numberOfAttr = numberOfAttributesOf(Circle.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Circle(item));
					break;
				case Shapes.COMPLEX:
					numberOfAttr = numberOfAttributesOf(Complex.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Complex(item));
					break;
				case Shapes.CONCAVE:
					numberOfAttr = numberOfAttributesOf(Concave.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Concave(item));
					break;
				case Shapes.CONE:
					numberOfAttr = numberOfAttributesOf(Cone.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Cone(item));
					break;	
				case Shapes.CUBE:
					numberOfAttr = numberOfAttributesOf(Cube.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Cube(item));
					break;
				case Shapes.CURVE:
					numberOfAttr = numberOfAttributesOf(Curve.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Curve(item));
					break;	
				case Shapes.CYLINDER:
					numberOfAttr = numberOfAttributesOf(Cylinder.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Cylinder(item));
					break;	
				case Shapes.ELLIPSE:
					numberOfAttr = numberOfAttributesOf(Ellipse.class) - 1;
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Ellipse(item));
					break;
				case Shapes.IRREGULAR_POLYGON:
					numberOfAttr = numberOfAttributesOf(IrregularPolygon.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new IrregularPolygon(item));
					break;
				case Shapes.LINE:
					numberOfAttr = numberOfAttributesOf(Line.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Line(item));
					break;
				case Shapes.LINE_SEGMENT:
					numberOfAttr = numberOfAttributesOf(LineSegment.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new LineSegment(item));
					break;
				case Shapes.NON_POLYHEDRA:
					numberOfAttr = numberOfAttributesOf(NonPolyhedra.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new NonPolyhedra(item));
					break;
				case Shapes.PLANE:
					numberOfAttr = numberOfAttributesOf(Plane.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Plane(item));
					break;
				case Shapes.PLATONIC_SOLID:
					numberOfAttr = numberOfAttributesOf(PlatonicSolid.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new PlatonicSolid(item));
					break;
				case Shapes.POINT:
					numberOfAttr = numberOfAttributesOf(Point.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Point(item));
					break;
				case Shapes.POLYGON:
					numberOfAttr = numberOfAttributesOf(Polygon.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Polygon(item));
					break;
				case Shapes.POLYHEDRA:
					numberOfAttr = numberOfAttributesOf(Polyhedra.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Polyhedra(item));
					break;
				case Shapes.PRISM:
					numberOfAttr = numberOfAttributesOf(Prism.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Prism(item));
					break;
				case Shapes.PYRAMID:
					numberOfAttr = numberOfAttributesOf(Pyramid.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Pyramid(item));
					break;
				case Shapes.RAY:
					numberOfAttr = numberOfAttributesOf(Ray.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Ray(item));
					break;
				case Shapes.REGULAR_POLYGON:
					numberOfAttr = numberOfAttributesOf(RegularPolygon.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new RegularPolygon(item));
					break;
				case Shapes.SHAPE:
					numberOfAttr = numberOfAttributesOf(Shape.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Shape(item));
					break;
				case Shapes.SOLID:
					numberOfAttr = numberOfAttributesOf(Solid.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Solid(item));
					break;
				case Shapes.SPHERE:
					numberOfAttr = numberOfAttributesOf(Sphere.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Sphere(item));
					break;
				case Shapes.TORUS:
					numberOfAttr = numberOfAttributesOf(Torus.class);
					if (numberOfAttr != item.length) {
						throw new Exception();
					}
					shapeList.add(new Torus(item));
					break;
				default:
					System.out.println("\"" + fileName + "\" has invalid name!");
					break;
				}
			}
		}
	}
	
	private static int numberOfAttributesOf(Class<?> c_class) {
		int result = 0;
		Class<?> current = c_class;
		
		while(current.getSuperclass() != null) {
			result += current.getDeclaredFields().length;
		    current = current.getSuperclass();
		}
		
		return result;
	}
	
	@SuppressWarnings("resource")
	private ArrayList<String[]> getAttributes(File file) {
		ArrayList<String[]> result = new ArrayList<>();
		Scanner fileScanner;
		
		try {
			fileScanner = new Scanner(file);
			
			while (fileScanner.hasNextLine()) {
				result.add(fileScanner.nextLine().split(SPLITTER));
			}
			
			return result;
			
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		}
		
		return null;
	}
	
	private void printObejctsIntoTextArea() {
		taContent.setText("");
		
		for (Shape shape : shapeList) {
			taContent.append(shape.toString());
		}
		
		taContent.setText(taContent.getText().trim());
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		if (e.getSource() == btnFile) {
            int returnVal = fc.showOpenDialog(frame);
 
            if (returnVal == JFileChooser.APPROVE_OPTION) {
            	files = fc.getSelectedFile().listFiles(new FilenameFilter() {
            	    public boolean accept(File dir, String name) {
            	        return name.toLowerCase().endsWith(".txt");
            	    }
            	});

                btnShow.setEnabled(true);
                try {
					readFiles();
				} catch (Exception e1) {
					e1.printStackTrace();
				}
                
            } else if (files == null) {
            	btnShow.setEnabled(false);
            }
        } else if (e.getSource() == btnShow) {
        	printObejctsIntoTextArea();
        }
	}
	
}
