import androidx.compose.foundation.layout.fillMaxSize
import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Surface
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.navigation.NavHostController
import androidx.navigation.compose.*
import org.example.project.ui.ClientListScreen
import org.example.project.ui.AddClientScreen
import org.example.project.ui.theme.YourAppTheme
import org.example.project.viewmodels.ClientViewModel
import org.example.project.viewmodels.ClientViewModelFactory
import org.example.project.shared.ClientsHelper
import androidx.compose.material.MaterialTheme
import androidx.compose.material.Surface
import androidx.compose.runtime.*
import androidx.navigation.compose.rememberNavController
import org.jetbrains.compose.ui.tooling.preview.Preview



@Composable
@Preview
fun App() {
    MaterialTheme {
        Surface(
            modifier = Modifier.fillMaxSize(),
            color = MaterialTheme.colors.background
        ) {
            val navController = rememberNavController()
            NavigationGraph(navController)
        }
    }
}


@Composable
fun NavigationGraph(navController: NavHostController) {
    NavHost(navController, startDestination = "clientList") {
        composable("clientList") { ClientListScreen(/* Pass ViewModel if needed */) }
        composable("addClient") { AddClientScreen(/* Pass ViewModel if needed */) }
    }
}