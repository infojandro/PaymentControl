import androidx.compose.foundation.layout.*
import androidx.compose.material.Button
import androidx.compose.material.Text
import androidx.compose.material.TextField
import androidx.compose.runtime.*
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewmodel.compose.viewModel

@Composable
fun AddClientScreen(clientViewModel: ClientViewModel = viewModel()) {
    var name by remember { mutableStateOf("") }
    var nick by remember { mutableStateOf("") }

    Column(modifier = Modifier.padding(16.dp)) {
        TextField(
            value = name,
            onValueChange = { name = it },
            label = { Text("Name") }
        )

        Spacer(modifier = Modifier.height(8.dp))

        TextField(
            value = nick,
            onValueChange = { nick = it },
            label = { Text("Nick") }
        )

        Spacer(modifier = Modifier.height(16.dp))

        Button(onClick = {
            clientViewModel.addClient(name, nick)
            // Navigate back or show confirmation
        }) {
            Text("Save Client")
        }
    }
}
