package dpteacher;

public class Teacher {
    private int id;
    private String firstName;
    private String lastName;
    private String title;
    private String pid;
    
    public Teacher() {
        
    }
    
    public Teacher(int id, String firstName, String lastName, 
            String title, String pid) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.title = title;
        this.pid = pid;
    }
    
    public int getId() {
        return id;
    }

    public String getFirstName() {
        return firstName;
    }
    
    public String getLastName() {
        return lastName;
    }

    public String getPid() {
        return pid;
    }

    public String getTitle() {
        return title;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }
    
    public void setLastName(String lastName) {
        this.lastName = lastName;
    }
    
    public void setPid(String pid) {
        this.pid = pid;
    }

    public void setTitle(String title) {
        this.title = title;
    }
    
    @Override
    public String toString() { 
        return (this.id + " " + this.title + " " + this.firstName + " " 
                + this.lastName + " " + this.pid);
    } 
}
