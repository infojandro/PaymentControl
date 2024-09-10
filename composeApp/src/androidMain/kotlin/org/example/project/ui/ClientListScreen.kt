import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.material.Button
import androidx.compose.material.Text
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.runtime.livedata.observeAsState
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewmodel.compose.viewModel

@Composable
fun ClientListScreen(clientViewModel: ClientViewModel = viewModel()) {
    val clients by clientViewModel.clients.observeAsState(emptyList())

    Column(modifier = Modifier.padding(16.dp)) {
        Button(onClick = { /* Navigate to AddClientScreen */ }) {
            Text("Add Client")
        }

        Spacer(modifier = Modifier.height(8.dp))

        LazyColumn {
            items(clients) { client ->
                Text(text = client.name)
                // Display more client details and add edit/delete options
            }
        }
    }

    // Observe changes and handle UI updates
    LaunchedEffect(Unit) {
        clientViewModel.loadAllClients()
    }
}
