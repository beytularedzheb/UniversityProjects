package dpteacher;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

public class TeacherSingleton {

    private final String connectionString = "jdbc:mysql://localhost:3306/test";
    private final String username = "root";
    private final String password = "root";

    private static TeacherSingleton instance = null;

    private TeacherSingleton() {
        
    }
    
    public static TeacherSingleton getInstance() {
        if (instance == null) {
            instance = new TeacherSingleton();
        }
        return instance;
    }

    static {
        try {
            Class.forName("org.gjt.mm.mysql.Driver");
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(TeacherSingleton.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public void addTeacher(Teacher teacher) {
        try (Connection con = DriverManager.getConnection(connectionString, username, password)) {
            
            String sql = "insert into teachers (fname, lname, pid, title)" +
                    "values(?, ?, ?, ?)";
            PreparedStatement preparedStatement = con.prepareStatement(sql);
            preparedStatement.setString(1, teacher.getFirstName());
            preparedStatement.setString(2, teacher.getLastName());
            preparedStatement.setString(3, teacher.getPid());
            preparedStatement.setString(4, teacher.getTitle());
            preparedStatement.executeUpdate();
            
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    public List<Teacher> getTeachers() {
        List<Teacher> result = null;
        try (Connection con = DriverManager.getConnection(connectionString, username, password)) {
            Statement statement = con.createStatement();
            String sql = "select * from teachers";
            ResultSet rs = statement.executeQuery(sql);
            if (rs != null && rs.next()) {
                result = new ArrayList<>();  
                do {
                    Teacher titem = new Teacher(rs.getInt("id"), 
                            rs.getString("fname"), 
                            rs.getString("lname"), 
                            rs.getString("title"), 
                            rs.getString("pid"));
                    result.add(titem);
                } while (rs.next());
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        return result;
    }

    public Teacher getTeacher(int id) {
        Teacher result = null;
        try (Connection con = DriverManager.getConnection(connectionString, username, password)) {
            Statement statement = con.createStatement();
            String sql = "select * from teachers where id = " + id;
            ResultSet rs = statement.executeQuery(sql);
            if (rs != null && rs.first()) {
                result = new Teacher(rs.getInt("id"), 
                        rs.getString("fname"), 
                        rs.getString("lname"), 
                        rs.getString("title"), 
                        rs.getString("pid"));
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        return result;
    }
}
