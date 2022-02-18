//Java program to read data of various types using Scanner class.
import java.util.Scanner;
import java.sql;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class User {
	/*public static void main(String[] args) {
		try (Connection conn = DriverManager.getConnection(
				"jdbc:postgresql://127.0.0.1:5433/Inferno", "postgres", "postgres")) {
			if (conn != null) {
				System.out.println("Connected to the database!");
				Statement st = conn.createStatement();
				ResultSet rs = st.executeQuery("SELECT * FROM \"Users\" WHERE \"UserID\" >0");
				while (rs.next())
				{
					System.out.print("Column 1 returned ");
					System.out.println(rs.getString(2));
				}
				rs.close();
				st.close();
			} 
			else {
				System.out.println("Failed to make connection!");
			}

		} 
		catch (SQLException e) {
			System.err.format("SQL State: %s\n%s", e.getSQLState(), e.getMessage());
		} 
		catch (Exception e) {
			e.printStackTrace();
		}	
	}
}*/
	public static void main(String[] args) {
		
		try (Connection conn = DriverManager.getConnection(
             "jdbc:postgresql://127.0.0.1:5433/Inferno", "postgres", "postgres")) {

         if (conn != null) {
             System.out.println("Connected to the database!");
         
             Statement st = conn.createStatement();
             ResultSet rs = st.executeQuery("SELECT * FROM \"Users\" WHERE \"UserID\" >0");
             while (rs.next())
             {
                 System.out.print("Column 1 returned ");
                 System.out.println(rs.getString(2));
             }
             rs.close();
             st.close();
         
         
         
         } else {
             System.out.println("Failed to make connection!");
         }

     } catch (SQLException e) {
         System.err.format("SQL State: %s\n%s", e.getSQLState(), e.getMessage());
     } catch (Exception e) {
         e.printStackTrace();
     }
		
	}

}

