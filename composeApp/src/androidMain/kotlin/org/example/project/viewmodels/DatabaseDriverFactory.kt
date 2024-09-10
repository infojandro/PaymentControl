import android.content.Context
import com.example.database.MyDatabase
import com.squareup.sqldelight.android.AndroidSqlDriver
import com.squareup.sqldelight.db.SqlDriver

class DatabaseDriverFactory(private val context: Context) {
    fun createDriver(): SqlDriver {
        return AndroidSqlDriver(MyDatabase.Schema, context, "mydatabase.db")
    }
}
